using System;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Collections.Generic;
using System.Timers;

public class PlayerHelper : IDisposable
{
    private static PlayerHelper _inst;
    private static object _locker = new object();
    public static PlayerHelper Inst()
    {
        if (_inst == null)
        {
            lock (_locker)
            {
                if (_inst == null)
                {
                    _inst = new PlayerHelper();
                }
            }
        }
        return _inst;
    }
    private Timer playTime;
    private WaveOutEvent outputDevice;
    private AudioFileReader audioFileReader;
    public List<string> PlayList;
    public int PlayListIndex { get; private set; }
    public PlayStyle PlayStyle { get; set; }
    public PlayerHelper()
    {
        PlayList = new List<string>();
        PlayListIndex = -1;
        PlayStyle = PlayStyle.list;

    }
    public void SetPlayTime(int minute)
    {
        playTime = new Timer();
        playTime.Interval = 1000 * 8;// minute * 60;
        playTime.Elapsed += PlayTime_Elapsed;
        playTime.Start();
    }
    private bool isSotpBySetPlayTime = false;
    private void PlayTime_Elapsed(object sender, ElapsedEventArgs e)
    {
        playTime.Stop();
        RunSlowly(-0.1F);
    }

    private void RunSlowly(float volum)
    {
        System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
        {
            RunSlowlyThread(volum);
        }));
        t.IsBackground = true;
        t.Start();
    }
    private void RunSlowlyThread(float volumSpan)
    {
        if (volumSpan > 0)
        {
            float tempVolume = 0;
            while (outputDevice.Volume < volumSpan)
            {
                tempVolume += 0.0001F;
                if (tempVolume > 1)
                {
                    tempVolume = volumSpan;
                }
                outputDevice.Volume = tempVolume;
                System.Threading.Thread.SpinWait(1000);
            }
        }
        else
        {
            float? volumne = outputDevice?.Volume;
            if (volumne.HasValue)
            {
                float tempVolumne = volumne.Value;
                while (tempVolumne > 0.1)
                {
                    tempVolumne = tempVolumne + volumSpan;
                    outputDevice.Volume = tempVolumne;
                    System.Threading.Thread.Sleep(1800);
                }
            }
            isSotpBySetPlayTime = true;
            outputDevice?.Stop();
            if (volumne.HasValue)
                outputDevice.Volume = volumne.Value;
        }
    }



    public void ClearList()
    {
        PlayList.Clear();
        PlayListIndex = -1;
    }

    public int Play(int index = -1, bool slowly = false)
    {
        if (index < 0 || PlayList.Count == 0)
        {
            return -1;
        }
        if (PlayList.Count <= index)
        {
            index = 0;
        }
        audioFileReader = new AudioFileReader(PlayList[index]);
        if (outputDevice != null)
        {
            outputDevice.Pause();
        }
        outputDevice = new WaveOutEvent();
        outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
        outputDevice.Init(audioFileReader);
        if (slowly)
        {
            float _volume = outputDevice.Volume;
            outputDevice.Volume = 0;
            RunSlowly(_volume);
        }
        outputDevice.Play();
        PlayListIndex = index;
        return PlayListIndex;
    }


    public void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
    {
        if (!isSotpBySetPlayTime && PlayStyle != PlayStyle.single)
        {
            Play(GetNextStepIndex());
        }
        if (isSotpBySetPlayTime)
            isSotpBySetPlayTime = false;
    }

    private int GetNextStepIndex()
    {
        int nextIndex = -1;
        switch (PlayStyle)
        {
            case PlayStyle.single:
                nextIndex = PlayListIndex;
                break;
            default: break;
            case PlayStyle.list:
                nextIndex = PlayList.Count < PlayListIndex ? 0 : PlayListIndex + 1;
                break;
            case PlayStyle.random:
                nextIndex = new Random().Next(0, PlayList.Count - 1);
                break;
        }
        return nextIndex;
    }

    /// <summary>
    /// 重新播放
    /// </summary>
    public void Rewind()
    {
        if (outputDevice?.PlaybackState != PlaybackState.Playing)
            return;
        if (audioFileReader != null)
        {
            audioFileReader.Position = 0;
        }
    }

    public void Stop()
    {
        if (outputDevice?.PlaybackState != PlaybackState.Playing)
            return;
        outputDevice?.Stop();
    }
    public void SetVolume(int vol = 20)
    {
        if (audioFileReader != null)
        {
            audioFileReader.Volume = vol / 100f;
        }
    }

    public void PlayNext()
    {
        if (outputDevice?.PlaybackState != PlaybackState.Playing)
            return;
        Play(GetNextStepIndex());
    }

    public void PlayPreview()
    {
        if (outputDevice?.PlaybackState != PlaybackState.Playing)
            return;
        switch (PlayStyle)
        {
            case PlayStyle.single:
            case PlayStyle.list:
                Play(PlayListIndex > 0 ? PlayListIndex - 1 : PlayList.Count - 1);
                break;
            case PlayStyle.random:
                Play(GetNextStepIndex());
                break;
            default:
                break;
        }
    }

    public void AddToList(string fileName)
    {
        PlayList.Add(fileName);
    }

    public void AddRangeToList(IEnumerable<string> files)
    {
        PlayList.AddRange(files);
    }

    public void Remove(string fileName)
    {
        if (PlayList.Contains(fileName))
        {
            PlayList.Remove(fileName);
        }
    }

    public void RemoveIndex(int index)
    {
        if (PlayList.Count > index && index > 0)
        {
            PlayList.RemoveAt(index);
        }
    }

    public string GetPlayingFile()
    {
        if (outputDevice?.PlaybackState != PlaybackState.Playing || PlayListIndex == -1)
            return string.Empty;
        return PlayList[PlayListIndex];
    }

    public void Dispose()
    {
        if (outputDevice != null)
        {
            outputDevice.Dispose();
            outputDevice = null;
        }
        if (audioFileReader != null)
        {
            audioFileReader.Dispose();
            audioFileReader = null;
        }
    }
}


public enum PlayStyle
{
    single = 0,
    list = 1,
    random = 2,
}