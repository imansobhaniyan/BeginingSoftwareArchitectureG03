﻿using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Bookings.Events;

public sealed record BookingCompletedDomainEvent(long BookingId) : IDomainEvent;