namespace PizzaPlace.BlazorServer.Shared.Component.ConfirmationModalPackage
{
    public static class ConfirmationModal
    {
        // Delegate and event to trigger modal
        internal delegate Task<bool> ShowModalDelegate(string text);
        internal static event ShowModalDelegate OnShowModal;

        public async static Task<bool> ShowAsync(string text)
        {
            // Ensure that OnShowModal is not null before invoking
            return OnShowModal is null? false: await OnShowModal.Invoke(text);
        }
    }
}
