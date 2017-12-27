using System;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Collections.Generic;
using System.Timers;

public class PlayerHelper : IDisposable
{
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
        playTime.Interval = 1000 * minute * 60;
        playTime.Elapsed += PlayTime_Elapsed;
        playTime.Start();
    }

    private void PlayTime_Elapsed(object sender, ElapsedEventArgs e)
    {
        outputDevice?.Pause();
    }

    public void ClearList()
    {
        PlayList.Clear();
        PlayListIndex = -1;
    }

    public int Play(int index = -1)
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
        outputDevice.Play();
        PlayListIndex = index;
        return PlayListIndex;
    }


    public void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
    {
        if (PlayStyle != PlayStyle.single)
        {
            Play(GetNextStepIndex());
        }
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