using System.Collections.Generic;

namespace my_app.App.Features.Interfaces
{
    public interface IService<T>
    {
        List<T> GetInfo();


    }
}
