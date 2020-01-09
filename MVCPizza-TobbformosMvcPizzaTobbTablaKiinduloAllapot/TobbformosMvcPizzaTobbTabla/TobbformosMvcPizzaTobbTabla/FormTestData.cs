using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TobbbformosPizzaAlkalmazasTobbTabla.Repository;

namespace TobbformosMvcPizzaTobbTabla
{
    public partial class FormPizzaFutarKft : Form
    {
        RepositoryDatabase rd = new RepositoryDatabase();
        RepositoryDatabaseTablePizza rdPizza = new RepositoryDatabaseTablePizza();
        RepositoryDatabaseTableCourier rdCourier = new RepositoryDatabaseTableCourier();

        private void torolHibauzenetet()
        {
            toolStripLabelHibauzenet.ForeColor = Color.Black;
            toolStripLabelHibauzenet.Text = "";
        }
        private void kiirHibauzenetet(string hibauzenet)
        {
            toolStripLabelHibauzenet.ForeColor = Color.Red;
            toolStripLabelHibauzenet.Text = hibauzenet;
        }

        private void adatázbázisLétrehozásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rd.createDatabase();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Adatbázis létrehozási hiba!");
            }
        }

        private void törölAdatbázisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rd.deleteDatabase();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Adatbázis törlési hiba!");
            }
        }

        private void feltöltésTesztadatokkalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rdPizza.createTablePizza();
                rdCourier.createTableCourier();

                rdPizza.fillPizzasWithTestDataFromSQLCommand();
                rdCourier.fillCourierWithTestDataFromSQLCommand();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Tesztadatok felöltése sikertelen!");
            }
        }

        private void törölTesztadatokatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rdPizza.deleteTablePizza();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Táblák törlése sikertelen!");
            }
        }
    }
}
