using ArchitectureSample.Application.Update;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureSample.Presentation.Update
{
    [ApiController]
    [Route("{id}")]
    public class UpdateController : ControllerBase
    {
        private readonly ILogger<UpdateController> logger;
        private readonly UpdateInputAdapter inputAdapter;
        private readonly UpdateUseCase useCase;

        public UpdateController(ILogger<UpdateController> logger, UpdateInputAdapter inputAdapter, UpdateUseCase useCase)
        {
            this.logger = logger;
            this.inputAdapter = inputAdapter;
            this.useCase = useCase;
        }

        [HttpPut]
        public async Task<IResult> Put(int id, UpdateParameter parameter)
        {
            this.logger.LogInformation("UpdateController.Put");

            var inputData = inputAdapter.Adapt(id, parameter);
            var outputData = await useCase.Execute(inputData);
            if (!outputData.Exists)
            {
                return TypedResults.NotFound();
            }
            else
            {
                return TypedResults.Ok();
            }
        }
    }
}
