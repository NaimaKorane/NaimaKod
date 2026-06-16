namespace Ovning5_Garage;

public class Manager
{
    private IUI ui;

    public Manager(IUI ui)
    {
        this.ui = ui;
    }

    public void Run()
    {
        ui.Start();
    }
}