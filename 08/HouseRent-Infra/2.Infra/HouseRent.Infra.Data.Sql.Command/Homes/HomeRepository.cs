﻿using HouseRent.Core.Domain.Homes;
using HouseRent.Core.Domain.Homes.Entities;
using HouseRent.Core.Domain.Homes.Repositories;
using HouseRent.Infra.Data.Sql.Command.Framework;
using HouseRent.Infra.Data.Sql.Command.Shared;

namespace HouseRent.Infra.Data.Sql.Command.Homes;

internal sealed class HomeRepository : BaseCommandRepository<Home,long>, IHomeRepository
{
    public HomeRepository(HouseRentDbContext dbContext)
        : base(dbContext)
    {
    }
}