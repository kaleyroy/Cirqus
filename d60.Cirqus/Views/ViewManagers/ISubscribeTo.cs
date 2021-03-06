﻿using d60.Cirqus.Events;

namespace d60.Cirqus.Views.ViewManagers
{
    public interface ISubscribeTo { }
    public interface ISubscribeTo<in TDomainEvent> : ISubscribeTo where TDomainEvent : DomainEvent
    {
        void Handle(IViewContext context, TDomainEvent domainEvent);
    }
}