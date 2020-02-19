namespace BusinessLogicLayer {
	public class cProfileSection{
	    private int _Id;
	    private cServiceProvider _ServiceProvider;
	    private cSectionHead _SectionHead;
	    private cSectionContent _SectionContent;

	    public int Id
	    {
		    get => _Id;
		    set => _Id = value;
	    }

	    public int ServiceProviderId { get; set; }
	    public virtual cServiceProvider ServiceProvider
	    {
		    get => _ServiceProvider;
		    set => _ServiceProvider = value;
	    }

	    public int SectionHeadId { get; set; }
	    public virtual cSectionHead SectionHead
	    {
		    get => _SectionHead;
		    set => _SectionHead = value;
	    }

	    public int SectionContentId { get; set; }
	    public virtual cSectionContent SectionContent
	    {
		    get => _SectionContent;
		    set => _SectionContent = value;
	    }
    }
}