using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Code.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static T ToModel<T>(this object entity)
        {
            return Mapper.Map<T>(entity);
        }

        public static T ToEntity<T>(this object viewModel)
        {
            if (viewModel == null)
                return default(T);

            return Mapper.Map<T>(viewModel);
        }

        public static IEnumerable<T> ToModelList<T>(this IEnumerable entityList)
        {
            if (entityList == null)
                return null;

            return (from object entity in entityList select entity.ToModel<T>()).ToList();
        }
    }
}