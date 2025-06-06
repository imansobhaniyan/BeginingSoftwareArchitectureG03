﻿using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Bookings.Events;
using HouseRent.Core.Domain.Bookings.Repositories;
using HouseRent.Core.Domain.Users;
using HouseRent.Core.Domain.Users.Repositories;
using MediatR;

namespace HouseRent.Core.ApplicationServices.Bookings.Events;

internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public BookingReservedDomainEventHandler(
        IBookingRepository bookingRepository,
        IUserRepository userRepository,
        IEmailService emailService)
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);

        if (booking is null)
        {
            return;
        }

        var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);

        if (user is null)
        {
            return;
        }

        await _emailService.SendAsync(
            user.Email,
            "خانه مورد نظر رزرو شد",
            "خانه مورد نظر رزرو شد. شما 30 دقیقه فرصت دارید تا رزرو خود را قطعی کنید.");
    }
}