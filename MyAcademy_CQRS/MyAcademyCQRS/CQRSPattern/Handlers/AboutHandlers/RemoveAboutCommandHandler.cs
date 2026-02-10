using MyAcademyCQRS.CQRSPattern.Commands.AboutCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;

public class RemoveAboutCommandHandler
{
    private readonly IUnitOfWork _uow;

    public RemoveAboutCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task Handle(RemoveAboutCommand command)
    {
        var value = await _uow.GetRepository<About>().GetByIdAsync(command.Id);
        if (value != null)
        {
            _uow.GetRepository<About>().Delete(value);
            await _uow.SaveChangesAsync();
        }
    }
}
