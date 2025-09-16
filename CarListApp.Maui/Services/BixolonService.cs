
using Com.Example.Bxlwrap;
using Java.Interop;


class Events : Java.Lang.Object, IPrinterEvents, IJavaPeerable
{
    public nint Handle => throw new NotImplementedException();

    public int JniIdentityHashCode => throw new NotImplementedException();

    public JniObjectReference PeerReference => throw new NotImplementedException();

    public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

    public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

    public void OnReady()
    {
        // obsługa gotowości drukarki
    }

    public void OnError(int code, string message)
    {
        // obsługa błędu
    }

    public void OnDisconnected()
    {
        // obsługa rozłączenia
    }

    public void SetJniIdentityHashCode(int value)
    {
        throw new NotImplementedException();
    }

    public void SetPeerReference(JniObjectReference reference)
    {
        throw new NotImplementedException();
    }

    public void SetJniManagedPeerState(JniManagedPeerStates value)
    {
        throw new NotImplementedException();
    }

    public void UnregisterFromRuntime()
    {
        throw new NotImplementedException();
    }

    public void DisposeUnlessReferenced()
    {
        throw new NotImplementedException();
    }

    public void Disposed()
    {
        throw new NotImplementedException();
    }

    public void Finalized()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
public class BixolonService
{
    BxlPrinterFacade _facade;

    public void Init()
    {
        _facade = new BxlPrinterFacade(Android.App.Application.Context);
        _facade.SetEvents(new Events());
        _facade.Init();
    }

    public bool Connect(string mac) => _facade.Connect(mac);
    public bool PrintText(string text) => _facade.PrintText(text);
    public void Close() => _facade.Close();
}
