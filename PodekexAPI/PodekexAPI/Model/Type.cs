using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodekexAPI.Model
{
    public class Type
    {
        public string Id { get; set; }
        public string PType { get; set; }
    }

    public class TypeValidator : AbstractValidator<Type>
    {

        public TypeValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.PType).NotNull();
            RuleFor(x => x.PType).NotEmpty();
            RuleFor(x => x.Id).Length(36);
            RuleFor(x => x.PType).Length(36);

        }
    }
}
