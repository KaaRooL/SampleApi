/* Copyright (C) 2023 Patco, LLC - All Rights Reserved. 
* You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC. 
*/

using Core.DomainEvent;

namespace Core.Base.Aggregate;

public class AggregateRootBase
{
    private HashSet<IDomainEvent> _events = new();
    private bool _versionIncremented;
    public int Version { get; protected set; }
    public IEnumerable<IDomainEvent> Events => _events;
    public DateTime CreatedAt { get; init; }
    public string CreatedBy { get; init; }
    public DateTime LastModifiedAt { get; private set; } = new DateTime().ToUniversalTime();
    public string LastModifiedBy { get; protected set; }
    public void ClearEvents() => _events.Clear();

    protected void AddEvent(IDomainEvent @event)
    {
        _events ??= new HashSet<IDomainEvent>();
            
        if (!_events.Any() && !_versionIncremented)
        {
            Version++;
            _versionIncremented = true;
            LastModifiedAt =  new DateTime().ToUniversalTime();
        }

        _events.Add(@event);
    }

    protected void IncrementVersion()
    {
        if (_versionIncremented)
        {
            return;
        }

        Version++;
        _versionIncremented = true;
    }
}