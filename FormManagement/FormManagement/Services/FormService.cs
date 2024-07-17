public class FormService : IFormService
{
	private readonly IRepository<FormModel> _formRepository;

	public FormService(IRepository<FormModel> formRepository)
	{
		_formRepository = formRepository;
	}

	public IEnumerable<FormModel> GetForms()
	{
		return _formRepository.GetAll();
	}

	public FormModel GetFormById(int id)
	{
		return _formRepository.GetById(id);
	}

	public void CreateForm(FormModel form)
	{
		_formRepository.Insert(form);
		_formRepository.Save();
	}

	public void UpdateForm(FormModel form)
	{
		_formRepository.Update(form);
		_formRepository.Save();
	}

	public void DeleteForm(int id)
	{
		_formRepository.Delete(id);
		_formRepository.Save();
	}
}
