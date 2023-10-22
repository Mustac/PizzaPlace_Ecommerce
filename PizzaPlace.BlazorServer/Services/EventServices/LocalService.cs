namespace PizzaPlace.BlazorServer.Services.EventServices
{
    public class LocalService
    {
        public NavMenuEventCollection NavMenuEvents { get; set; }

        public LocalService()
        {
            NavMenuEvents = new NavMenuEventCollection();
        }

        /// <summary>
        /// Class responsible for holding Navigation Menu Events
        /// </summary>
        public class NavMenuEventCollection
        { 
            public event Func<Task>? OnMenuOpen;
            public event Func<Task>? OnMenuClose;

            public Trigger? Triggers { get; set; }

            public NavMenuEventCollection()
            {
                Triggers = new Trigger(this);
            }

            /// <summary>
            /// Class responsible to trigger Navigation Menu Events
            /// </summary>
            public class Trigger
            {
                private readonly NavMenuEventCollection _navMenuEvents;
                public Trigger(NavMenuEventCollection navMenuEvents)
                {
                    _navMenuEvents = navMenuEvents;
                }

                public async Task TriggerOnMenuOpen()
                {
                    if (_navMenuEvents.OnMenuOpen is not null)
                        await _navMenuEvents.OnMenuOpen.Invoke();
                }

                public async Task TriggerOnMenuClose()
                {
                    if (_navMenuEvents.OnMenuClose is not null)
                        await _navMenuEvents.OnMenuClose.Invoke();
                }
            }


        }
    }

}
