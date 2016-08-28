using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilmCollection
{
    public partial class Actors : Form
    {
        private DataSet dataSet;
        private Hashtable fieldProps;
        private Hashtable sectionProps;


        public Actors()
        {
            InitializeComponent();
        }


        private void LoadFields()
        {
            //chkLeftFelds.Items.Clear();
            //cmbChangeOnField.Items.Clear();
            //cmbValueField.Items.Clear();
            //cmbValueField.Items.Add("COUNT");
            //foreach (DataColumn dc in dataSet.Tables[0].Columns)
            //{
            //    chkLeftFelds.Items.Add(dc.ColumnName);
            //    cmbChangeOnField.Items.Add(dc.ColumnName);
            //    cmbValueField.Items.Add(dc.ColumnName);
            //}
        }

        private void btnMoveUp_Click(object sender, System.EventArgs e)
        {
            int index = chkLeftFelds.SelectedIndices[0];
            if (index != 0)
            {
                ArrayList list = new ArrayList();
                CheckedListBox cb = new CheckedListBox();
                cb.Items.AddRange(chkLeftFelds.Items);
                for (int i = 0; i < chkLeftFelds.CheckedItems.Count; i++)
                {
                    cb.SetItemCheckState(cb.Items.IndexOf(chkLeftFelds.CheckedItems[i]), CheckState.Checked);
                }
                list.AddRange(chkLeftFelds.Items);
                ArrayList newlist = new ArrayList(list);
                newlist[index] = list[index - 1];
                newlist[index - 1] = list[index];
                chkLeftFelds.Items.Clear();
                chkLeftFelds.Items.AddRange((string[])newlist.ToArray(typeof(string)));
                for (int i = 0; i < cb.CheckedItems.Count; i++)
                {
                    chkLeftFelds.SetItemCheckState(chkLeftFelds.Items.IndexOf(cb.CheckedItems[i]), CheckState.Checked);
                }
                chkLeftFelds.SelectedItem = chkLeftFelds.Items[index - 1];
            }
        }


        private void btnMoveDown_Click(object sender, System.EventArgs e)
        {
            int index = chkLeftFelds.SelectedIndices[0];
            if (index != chkLeftFelds.Items.Count - 1)
            {
                CheckedListBox cb = new CheckedListBox();
                cb.Items.AddRange(chkLeftFelds.Items);
                for (int i = 0; i < chkLeftFelds.CheckedItems.Count; i++)
                {
                    cb.SetItemCheckState(cb.Items.IndexOf(chkLeftFelds.CheckedItems[i]), CheckState.Checked);
                }
                ArrayList list = new ArrayList();
                list.AddRange(chkLeftFelds.Items);
                ArrayList newlist = new ArrayList(list);
                newlist[index] = list[index + 1];
                newlist[index + 1] = list[index];
                chkLeftFelds.Items.Clear();
                chkLeftFelds.Items.AddRange((string[])newlist.ToArray(typeof(string)));
                for (int i = 0; i < cb.CheckedItems.Count; i++)
                {
                    chkLeftFelds.SetItemCheckState(chkLeftFelds.Items.IndexOf(cb.CheckedItems[i]), CheckState.Checked);
                }
                chkLeftFelds.SelectedItem = chkLeftFelds.Items[index + 1];
            }
        }


        private void btnAddGroup_Click(object sender, System.EventArgs e)
        {
            if (chkLeftFelds.SelectedItems.Count > 0)
            {
                if (!chkRightFelds.Items.Contains(chkLeftFelds.SelectedItems[0].ToString()))
                {
                    // chkRightFelds.Items.Add(chkLeftFelds.SelectedItems[0].ToString());
                    // CreateSectionProps(chkLeftFelds.SelectedItems[0].ToString());


                    //chkLeftFelds.CheckedItems.OfType<string>().ToList().ForEach(chkRightFelds.Items.Add());
                    foreach (var item in chkLeftFelds.CheckedItems.OfType<string>().ToList())
                    {
                        if (!chkRightFelds.Items.Contains(item))
                        {
                            chkRightFelds.Items.Add(item);
                        }
                    }

                    //var items = new System.Collections.ArrayList(chkLeftFelds.SelectedItems);

                    //foreach (var item in items)
                    //{
                    //    chkRightFelds.Items.Add(item);
                    //   // listbox.Items.remove(item);

                    //}


                }
            }
        }

        private void btnRemoveGroup_Click(object sender, System.EventArgs e)
        {
            if (chkRightFelds.SelectedItems.Count > 0)
            {
                string secName = chkRightFelds.SelectedItems[0].ToString();
                chkRightFelds.Items.Remove(chkRightFelds.SelectedItems[0]);
                //УБРАТЬ check
               // chkLeftFelds.ch// chkLeftFelds.Items.IndexOf(chkRightFelds.SelectedItems[0])
                //sectionProps.Remove(secName);





            }
        }

        private void chkLstFields_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // SaveFieldAttributes(selectedField);
            if (chkLeftFelds.SelectedItems.Count > 0)
            {
                //LoadFieldAttributes(chkLstFields.SelectedItems[0].ToString());
            }
        }

        private void lstGroupBy_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //SaveSectionAttributes(selectedSection);
            if (chkRightFelds.SelectedItems.Count > 0)
            {
                LoadSectionAttributes(chkRightFelds.SelectedItems[0].ToString());
            }
        }

        private void CreateSectionProps(string groupByColumnName)
        {
            //sectionProps.Add(groupByColumnName, new Section(groupByColumnName, ""));
        }

        private void SaveFieldAttributes(string fieldName)
        {
            //if (fieldProps[fieldName] != null)
            //{
            //    Field field = (Field)fieldProps[fieldName];
            //    field.FieldName = lblColumnName.Text;
            //    field.HeaderName = txtHeaderText.Text;
            //    field.HeaderBackColor = pnlHBG.BackColor;
            //    field.BackColor = pnlBG.BackColor;
            //    field.Width = int.Parse(txtWidth.Text);
            //    field.Alignment = (cmbAlignment.Text == "RIGHT") ? ALIGN.RIGHT : (cmbAlignment.Text == "CENTER") ? ALIGN.CENTER : ALIGN.LEFT;
            //    field.isTotalField = chkTotalField.Checked;
            //}
        }

        private void LoadSectionAttributes(string sectionName)
        {
            //if (sectionProps[sectionName] != null)
            //{
            //    Section section = (Section)sectionProps[sectionName];
            //    lblSectionName.Text = sectionName;
            //    txtTitlePrefix.Text = section.TitlePrefix;
            //    pnlSecBGColor.BackColor = section.BackColor;
            //    chkGradient.Checked = section.GradientBackground;
            //    chkTotalRow.Checked = section.IncludeTotal;
            //    chkChart.Checked = section.IncludeChart;
            //    chkChartAtBottom.Checked = section.ChartShowAtBottom;
            //    chkBorder.Checked = section.ChartShowBorder;
            //    if (section.IncludeChart)
            //    {
            //        grpChartProps.Enabled = true;
            //        txtChartTitle.Text = section.ChartTitle;
            //        cmbChangeOnField.Text = section.ChartChangeOnField;
            //        cmbValueField.Text = section.ChartValueField == "" ? "COUNT" : section.ChartValueField;
            //        txtLabelText.Text = section.ChartLabelHeader;
            //        txtPercentageText.Text = section.ChartPercentageHeader;
            //        txtValueText.Text = section.ChartValueHeader;
            //    }
            //    else
            //    {
            //        grpChartProps.Enabled = false;
            //        txtChartTitle.Text = "";
            //        cmbChangeOnField.Text = "";
            //        cmbValueField.Text = "";
            //        txtLabelText.Text = "";
            //        txtPercentageText.Text = "";
            //        txtValueText.Text = "";
            //    }
            //}
            //selectedSection = sectionName;
        }
    }
}
