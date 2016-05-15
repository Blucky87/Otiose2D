namespace Otiose.Input
{
    public interface BindingSourceListener
    {
        void Reset();
        BindingSource Listen(BindingListenOptions listenOptions, InputDevice device);
    }
}