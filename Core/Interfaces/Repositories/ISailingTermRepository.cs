﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
	public interface IGuitarTermRepository
	{
		Task<IReadOnlyCollection<GuitarTerm>> GetAll();
	}
}
