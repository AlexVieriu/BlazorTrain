using Microsoft.AspNetCore.Components;
using System;

namespace AppState_ServiceMethod.Services
{
    public class AppState
    {
        // set Message, Enabled, Counter only with the internal methods:
        // UpdateMessage, UpdateEnabled, UpdateCounter
        public string Message { get; private set; } = "";
        public bool Enabled { get; private set; } = false;
        public int Counter { get; private set; } = 0;

        public void UpdateMessage(ComponentBase Source, string Message)
        {
            this.Message = Message;
            NotifyStateChanged(Source, "Message");
        }

        public void UpdateEnabled(ComponentBase Source, bool Enabled)
        {
            this.Enabled = Enabled;
            NotifyStateChanged(Source, "Enabled");
        }

        public void UpdateCounter(ComponentBase Source, int Counter)
        {
            this.Counter= Counter;
            NotifyStateChanged(Source, "Counter");
        }

        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) =>
            StateChanged?.Invoke(Source, Property);
    }
}
