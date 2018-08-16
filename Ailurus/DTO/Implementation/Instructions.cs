using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ailurus.DTO.Implementation.DroneInstruction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ailurus.DTO
{
    public class Instructions<TCoordinate> : IInstructions<TCoordinate> where TCoordinate : ICoordinate
    {
        public IEnumerable<IDroneInstruction<TCoordinate>> DroneInstruction { get; set; }
    }
/*
    public class InstructionModelBinder : IModelBinder
    {

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)  
                throw new ArgumentNullException(nameof(bindingContext));  
  
            var values = bindingContext.ValueProvider.GetValue("Value");  
            if (values.Length == 0)  
                return Task.CompletedTask;  
  
            var splitData = values.FirstValue.Split(new char[] { '|' });  
            if (splitData.Length >= 2)  
            {  
                var result = new Collect<CoordinateInt2D>
                {  
                    DroneName = ""
                };  
                bindingContext.Result = ModelBindingResult.Success(result);  
            }  
  
            return Task.CompletedTask;  
        }
    }
*/
}