﻿/*
    Copyright (C) 2014  Muraad Nofal
    Contact: muraad.nofal@gmail.com
 
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * */

using System;
using System.Linq;

namespace Restless.Extensions
{
    public static class TExtension
    {
        public static void ThrowIfNull<T>(this T obj, string name = "")
        {
            if(obj == null)
            {
                if(String.IsNullOrEmpty(name))
                    name = obj.GetType().Name;
                throw new ArgumentNullException(name);
            }
        }

        public static void SetFrom<T>(this T to, T from, params string[] excludePropertys)
        {
            var propertys = to.GetType().GetProperties();
            for (int i = 0; i < propertys.Length; i++)
            {
                var prop = propertys[i];
                if (prop.CanWrite && prop.CanRead && !excludePropertys.Contains(prop.Name))
                {
                    prop.SetValue(to, prop.GetValue(from));
                }
            }
        }
    }
}