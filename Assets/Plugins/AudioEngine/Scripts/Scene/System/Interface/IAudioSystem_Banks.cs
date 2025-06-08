namespace AudioEngine
{
    public partial interface IAudioSystem
    {
        bool LoadBank(AudioBank audioBank);
        bool UnloadBank(AudioBank audioBank);
    }
}