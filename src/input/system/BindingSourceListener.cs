namespace Otiose2D.Input
{
    public interface BindingSourceListener
    {
        void Reset();
        BindingSource Listen(BindingListenOptions listenOptions, InputDevice device);
    }
}