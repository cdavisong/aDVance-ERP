using aDVancePOS.Mobile.Models;

using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace aDVancePOS.Mobile.Adapters {
    // Adapters/ProductoAdapter.cs
    public class ProductoAdapter : RecyclerView.Adapter {
        private List<Producto> _productos;
        private Action<Producto> _onItemClick;

        public ProductoAdapter(List<Producto> productos, Action<Producto> onItemClick) {
            _productos = productos;
            _onItemClick = onItemClick;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_producto, parent, false);
            return new ProductoViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
            if (holder is ProductoViewHolder productoHolder) {
                var producto = _productos[position];
                productoHolder.Bind(producto, () => _onItemClick?.Invoke(producto));
            }
        }

        public override int ItemCount => _productos.Count;

        public void UpdateData(List<Producto> nuevosProductos) {
            _productos = nuevosProductos;
            NotifyDataSetChanged();
        }
    }

    public class ProductoViewHolder : RecyclerView.ViewHolder {
        private TextView _txtNombre;
        private TextView _txtPrecio;
        private TextView _txtStock;

        public ProductoViewHolder(View itemView) : base(itemView) {
            _txtNombre = itemView.FindViewById<TextView>(Resource.Id.txtNombreProducto);
            _txtPrecio = itemView.FindViewById<TextView>(Resource.Id.txtPrecioProducto);
            _txtStock = itemView.FindViewById<TextView>(Resource.Id.txtStockProducto);
        }

        public void Bind(Producto producto, Action onClick) {
            _txtNombre.Text = producto.Nombre;
            _txtPrecio.Text = producto.PrecioVentaBase.ToString("C");
            _txtStock.Text = $"Stock: {producto.Stock} {producto.AbreviaturaMedida}";

            ItemView.Click += (sender, e) => onClick?.Invoke();
        }
    }
}