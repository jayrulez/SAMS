using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Presenters;

namespace WebApi.Entities
{
    public static class Presenters 
    {
        public static UserPresenter ToPresenter(this User source)
        {
            var destination = new UserPresenter();

            destination.Id = source.Id;
            destination.UserName = source.UserName;
            if(source.Location != null)
            {
                destination.Location = source.Location.ToPresenter();
            }

            return destination;
        }

        public static LocationPresenter ToPresenter(this Location source)
        {
            var destination = new LocationPresenter();

            destination.Id = source.Id;
            destination.Name = source.Name;
            if (source.Parent != null)
            {
                destination.Parent = source.Parent.ToPresenter();
            }

            return destination;
        }
    }
}