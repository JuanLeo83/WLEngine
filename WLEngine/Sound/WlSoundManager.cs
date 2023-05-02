using Microsoft.Xna.Framework.Content;
using WLEngine.Event;

namespace WLEngine.Sound; 

public abstract class WlSoundManager<T, TM> {
    private readonly ContentManager _contentManager;
    private readonly string _path;
    protected readonly Dictionary<Type, TM?> bank = new();

    protected WlSoundManager(ContentManager contentManager, string path) {
        _contentManager = contentManager;
        _path = path;
    }

    public TM? register(WlGameEvent gameEvent, string name) {
        var resource = _contentManager.Load<T>(getPath(name));
        if (resource == null) return default;
        
        var sound = map(resource);
        bank.Add(gameEvent.GetType(), sound);
        return sound;
    }

    public void onNotify(WlGameEvent gameEvent, object? argument = null) {
        if (!bank.ContainsKey(gameEvent.GetType())) return;

        var sound = bank[gameEvent.GetType()];
        resolveEvent(sound, argument);
    }

    protected abstract void resolveEvent(TM? sound, object? argument = null);

    private string getPath(string name) => $"{_path}/{name}";

    protected abstract TM? map(T resource);

    public abstract void dispose();
}