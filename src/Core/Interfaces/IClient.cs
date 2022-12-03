using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces;

public interface IClient<TParams, TModel>
{
  Task<ActionResponse> Invoke(TParams param);
}
