using aDVanceERP.Core.Datos.Interfaces;

using System.Collections.ObjectModel;

namespace aDVanceERP.Core.Datos.Modelos;

public class ColeccionEntidades<En> : ReadOnlyCollection<En>
    where En : class, IEntidad, new() {
    public ColeccionEntidades(IList<En> list) : base(list) { }

    public new virtual En this[int indice] => Items[indice];

    public void CopiarA(En[] array, int indice) {
        Items.CopyTo(array, indice);
    }
}
