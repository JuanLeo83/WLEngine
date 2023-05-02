using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using WLEngine.Event;

namespace WLEngine.Sound;

public class WlMusicManager : WlSoundManager<SoundEffect, SoundEffectInstance> {
    public WlMusicManager(ContentManager contentManager) : base(contentManager, "Music") { }

    private SoundEffectInstance? _currentTrack;

    public void register(WlGameEvent gameEvent, string name, bool isLooped = false, float volume = 1.0f) {
        var sound = base.register(gameEvent, name);
        if (sound == null) return;

        sound.IsLooped = isLooped;
        sound.Volume = volume;
    }

    protected override void resolveEvent(SoundEffectInstance? sound, object? argument = null) {
        if (argument == null) return;

        var action = (Action)argument;
        switch (action) {
            case Action.SetCurrent:
                _currentTrack = sound;
                break;
            case Action.Play:
                play();
                break;
            case Action.Pause:
                pause();
                break;
            case Action.Stop:
                stop();
                break;
            case Action.IncrementVolume:
                incrementVolume();
                break;
            case Action.DecrementVolume:
                decrementVolume();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void play() {
        if (_currentTrack is { State: SoundState.Playing }) return;
        _currentTrack?.Play();
    }

    private void stop() {
        if (_currentTrack is { State: SoundState.Stopped }) return;
        _currentTrack?.Stop();
    }

    private void pause() {
        if (_currentTrack?.State != SoundState.Playing) return;
        _currentTrack?.Pause();
    }

    private void incrementVolume() {
        if (_currentTrack == null) return;
        _currentTrack.Volume += 0.1f;
    }

    private void decrementVolume() {
        if (_currentTrack == null) return;
        _currentTrack.Volume -= 0.1f;
    }

    protected override SoundEffectInstance map(SoundEffect resource) {
        return resource.CreateInstance();
    }

    public override void dispose() {
        foreach (var sound in bank) {
            sound.Value?.Dispose();
        }
    }

    public enum Action {
        SetCurrent,
        Play,
        Pause,
        Stop,
        IncrementVolume,
        DecrementVolume
    }
}