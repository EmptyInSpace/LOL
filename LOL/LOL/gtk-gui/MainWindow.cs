
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	
	private global::Gtk.Action Action;
	
	private global::Gtk.Action gfdghAction;
	
	private global::Gtk.Action gdhfAction;
	
	private global::Gtk.Action Action1;
	
	private global::Gtk.Action Action21;
	
	private global::Gtk.Action gfdgAction;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.Action = new global::Gtk.Action ("Action", global::Mono.Unix.Catalog.GetString ("База данных"), null, null);
		this.Action.ShortLabel = global::Mono.Unix.Catalog.GetString ("База данных");
		w1.Add (this.Action, null);
		this.gfdghAction = new global::Gtk.Action ("gfdghAction", global::Mono.Unix.Catalog.GetString ("gfdgh"), null, null);
		this.gfdghAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("gfdgh");
		w1.Add (this.gfdghAction, null);
		this.gdhfAction = new global::Gtk.Action ("gdhfAction", global::Mono.Unix.Catalog.GetString ("gdhf"), null, null);
		this.gdhfAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("gdhf");
		w1.Add (this.gdhfAction, null);
		this.Action1 = new global::Gtk.Action ("Action1", null, null, null);
		this.Action1.ShortLabel = "";
		w1.Add (this.Action1, null);
		this.Action21 = new global::Gtk.Action ("Action21", null, null, null);
		this.Action21.ShortLabel = "";
		w1.Add (this.Action21, null);
		this.gfdgAction = new global::Gtk.Action ("gfdgAction", global::Mono.Unix.Catalog.GetString ("gfdg"), null, null);
		this.gfdgAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("gfdg");
		w1.Add (this.gfdgAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 885;
		this.DefaultHeight = 564;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
	}
}