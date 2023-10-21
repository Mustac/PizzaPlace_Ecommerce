namespace PizzaPlace.BlazorServer.Services.EventServices;

public delegate Task ProductEventHandler(ProductDTO productDto);

public class GlobalService
{
    public ProductEvents Product { get; set; }

    public GlobalService()
    {
        Product = new ProductEvents();
    }

    public class ProductEvents
    {
        public ProductEvents()
        {
            EventTriggers = new Triggers(this);
        }

        public Triggers EventTriggers { get; }

        public event ProductEventHandler? OnProductUpdated;
        public event ProductEventHandler? OnProductArchived;
        public event ProductEventHandler? OnProductRestored;
        public event ProductEventHandler? OnProductDeleted;
        public event ProductEventHandler? OnProductCreated;
        public event ProductEventHandler? OnProductChange;

        /// <summary>
        /// Event trigger object for ProductEvents
        /// </summary>
        public class Triggers
        {
            private readonly ProductEvents _productEvents;

            public Triggers(ProductEvents productEvents)
            {
                _productEvents = productEvents;
            }

            /// <summary>
            /// Triggers the OnProductUpdated event. Additionally, triggers the OnProductChange event.
            /// </summary>
            /// <param name="productDto">The product data transfer object representing the updated product.</param>
            /// <returns>A Task representing the asynchronous operation.</returns>
            public async Task TriggerProductUpdated(ProductDTO productDto)
            {
                if (_productEvents.OnProductUpdated is not null)
                    await _productEvents.OnProductUpdated.Invoke(productDto);

                if (_productEvents.OnProductChange is not null)
                    await _productEvents.OnProductChange.Invoke(productDto);
            }

            /// <summary>
            /// Triggers the OnProductArchived event. Additionally, triggers the OnProductChange event.
            /// </summary>
            /// <param name="productDto">The product data transfer object representing the archived product.</param>
            /// <returns>A Task representing the asynchronous operation.</returns>
            public async Task TriggerProductArchived(ProductDTO productDto)
            {
                if (_productEvents.OnProductArchived is not null)
                    await _productEvents.OnProductArchived.Invoke(productDto);

                if (_productEvents.OnProductChange is not null)
                    await _productEvents.OnProductChange.Invoke(productDto);
            }

            /// <summary>
            /// Triggers the OnProductRestored event. Additionally, triggers the OnProductChange event.
            /// </summary>
            /// <param name="productDto">The product data transfer object representing the product involved in the restoration.</param>
            /// <returns>A Task representing the asynchronous operation.</returns>
            public async Task TriggerProductRestored(ProductDTO productDto)
            {
                if (_productEvents.OnProductRestored is not null)
                    await _productEvents.OnProductRestored.Invoke(productDto);

                if (_productEvents.OnProductChange is not null)
                    await _productEvents.OnProductChange.Invoke(productDto);
            }

            /// <summary>
            /// Triggers the OnProductDeleted event. Additionally, triggers the OnProductChange event.
            /// </summary>
            /// <param name="productDto">The product data transfer object representing the deleted product.</param>
            /// <returns>A Task representing the asynchronous operation.</returns>
            public async Task TriggerProductDeleted(ProductDTO productDto)
            {
                if (_productEvents.OnProductDeleted is not null)
                    await _productEvents.OnProductDeleted.Invoke(productDto);

                if (_productEvents.OnProductChange is not null)
                    await _productEvents.OnProductChange.Invoke(productDto);
            }

            /// <summary>
            /// Triggers the OnProductCreated event. Additionally, triggers the OnProductChange event.
            /// </summary>
            /// <param name="productDto">The product data transfer object representing the newly created product.</param>
            /// <returns>A Task representing the asynchronous operation.</returns>
            public async Task TriggerProductCreated(ProductDTO productDto)
            {
                if (_productEvents.OnProductCreated is not null)
                    await _productEvents.OnProductCreated.Invoke(productDto);

                if (_productEvents.OnProductChange is not null)
                    await _productEvents.OnProductChange.Invoke(productDto);
            }

        }
    }
}


