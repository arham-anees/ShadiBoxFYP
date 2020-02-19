namespace BusinessLogicLayer {
	public class cServiceType {
	    private int _Id;
	    private string _Name;
	    private string _Description;

	    public int Id
	    {
		    get => _Id;
		    set => _Id = value;
	    }

	    public string Name
	    {
		    get => _Name;
		    set => _Name = value;
	    }

	    public string Description
	    {
		    get => _Description;
		    set => _Description = value;
	    }

    }
}