namespace FoodApp.Api.VerticalSlicing.Features.Account.Register;

public class RegisterEndPoint : BaseController
{
    public RegisterEndPoint(ControllerParameters controllerParameters) : base(controllerParameters) { }

    [HttpPost("Account/Register")]
    public async Task<Result> Register(RegisterRequest viewModel)
    {
        var command = viewModel.Map<RegisterOrchestrator>();
        var result = await _mediator.Send(command);
        return result;
    }
}
