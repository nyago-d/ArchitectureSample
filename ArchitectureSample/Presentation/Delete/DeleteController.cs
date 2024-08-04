using ArchitectureSample.Application.Delete;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureSample.Presentation.Delete
{
    [ApiController]
    [Route("{id}")]
    public class DeleteController : ControllerBase
    {
        private readonly ILogger<DeleteController> logger;
        private readonly DeleteInputAdapter inputAdapter;
        private readonly DeleteUseCase useCase;

        public DeleteController(ILogger<DeleteController> logger, DeleteInputAdapter inputAdapter, DeleteUseCase useCase)
        {
            this.logger = logger;
            this.inputAdapter = inputAdapter;
            this.useCase = useCase;
        }

        [HttpDelete]
        public async Task<IResult> Delete(int id)
        {
            this.logger.LogInformation("DeleteController.Delete");

            var inputData = inputAdapter.Adapt(id);
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
