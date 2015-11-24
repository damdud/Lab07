using System;

namespace UamTTA.Model
{
    public interface IEntity : ICloneable
    {
        int? Id { get; set; }
    }
}