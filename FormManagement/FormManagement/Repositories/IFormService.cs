public interface IFormService
{
	IEnumerable<FormModel> GetForms();
	FormModel GetFormById(int id);
	void CreateForm(FormModel form);
	void UpdateForm(FormModel form);
	void DeleteForm(int id);
}
