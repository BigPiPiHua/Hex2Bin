//#define Encrypt
//#define Decrypt
//#define DebugOut

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;


namespace Hex2Bin
{
    public partial class frMain : Form
    {
        String szBinPath = "";
        String szHexPath = "";
        public frMain()
        {
            InitializeComponent();
        }
        private void frMain_Load(object sender, EventArgs e)
        {
            //加载注册表参数
            if (Tool.GetRegist("MergeBoot") == "1")
            {
                MergeBoot.Checked = true;
            }
            else
            {
                MergeBoot.Checked = false;
            }
            if (Tool.GetRegist("SaveMergeHex") == "1")
            {
                SaveMergeHex.Checked = true;
            }
            else
            {
                SaveMergeHex.Checked = false;
            }
        }
        private void frMain_DragEnter(object sender, DragEventArgs e)                                         //获得“信息”
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;                                                              //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }
        private void frMain_DragDrop(object sender, DragEventArgs e) //拖拽文件
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();    //获得路径
            tbHexPath.Text = path;           //由一个textBox显示路径
            if (Path.GetExtension(path) == ".hex" || Path.GetExtension(path) == ".HEX")
            {
                btnConvert.PerformClick();//直接转换
            }
        }
        private void frMain_BtnPress(object sender, KeyEventArgs e)//按键触发
        {
            if(e.KeyValue == 112)//F1
            {
                btnOpenHex.PerformClick();//直接打开文件
            }
            else if (e.KeyValue == 113)//F2
            {
                btnOut.PerformClick();//直接输出
            }
            else if (e.KeyValue == 115)//F4
            {
                btnConvert.PerformClick();//直接转换
            }
        }
        private void MergeBoot_CheckedChanged(object sender, EventArgs e)
        {
            if (MergeBoot.Checked == true)
            {
                if (!File.Exists(@"Boot.hex"))
                {
                    MergeBoot.Checked = false;
                    MessageBox.Show("请在当前程序目录放入启动hex文件并命名为Boot.hex", "提示");
                }
                else
                {
                    SaveMergeHex.Visible = true;
                    Tool.SetRegist("MergeBoot", "1");
                }
            }
            else
            {
                SaveMergeHex.Visible = false;
                Tool.SetRegist("MergeBoot", "0");
            }
        }
        private void SaveMergeHex_CheckedChanged(object sender, EventArgs e)
        {
            if (SaveMergeHex.Checked == true)
            {
                Tool.SetRegist("SaveMergeHex", "1");
            }
            else
            {
                Tool.SetRegist("SaveMergeHex", "0");
            }
        }
        private void btnOpenHex_Click(object sender, EventArgs e)
        {
            try
            {
                pbConvert.Value = 0;
                if (openHexDlg.ShowDialog() == DialogResult.OK) //打开转换的目标文件
                {
                    tbHexPath.Text = openHexDlg.FileName;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveBinDlg.ShowDialog() == DialogResult.OK)
                {
                    tbBinPath.Text = saveBinDlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnConvert_Click(object sender, EventArgs e)
        {
            //转换时使3个按钮不可以点击
            btnOpenHex.Enabled = false;
            btnOut.Enabled = false;
            btnConvert.Enabled = false;
            try
            {
                Int32 i;
                Int32 j = 0;
                String szTxt = "";//合并HEX文件的数据
                String szLine = "";//Hex文件每行的数据
                String szHex = "";//bin文件的HEX字符串数据
                int startAdr = 0;//起始地址
                int endAdr = 0;   //用于判断hex地址是否连续，不连续补充0xFF
                int lineLenth;//当前行的数据长度
                bool FirstLineFlag;//起始行标志位
                bool FirstAddrFlag;//起始地址标志位
                szHexPath = tbHexPath.Text;//HEX文件路径
                szBinPath = tbBinPath.Text;//Bin文件路径
                if (szHexPath == "")
                {
                    MessageBox.Show("请选择需要转换的hex文件!         ", "提示");
                    return;
                }
                pbConvert.Maximum = 100;
                #region 读取并处理Boot.hex
                if (MergeBoot.Checked == true)//读取启动文件
                {
                    if (!File.Exists(@"Boot.hex"))
                    {
                        MergeBoot.Checked = false;
                        MessageBox.Show("请在当前程序目录放入启动hex文件并命名为Boot.hex", "提示");
                        return;
                    }
                    pbConvert.Value = 10;
                    StreamReader BootHexReader = new StreamReader("Boot.hex");
                    FirstAddrFlag = true;
                    while (true)
                    {
                        szLine = BootHexReader.ReadLine(); //读取Hex中一行
                        if (szLine == null) { break; } //读取完毕，退出
                        if (szLine.Substring(0, 1) == ":") //判断首字符是”:”
                        {
                            if (szLine.Substring(7, 2) == "00")//数据记录
                            {
                                if (SaveMergeHex.Checked == true)
                                {
                                    szTxt += szLine + "\r\n";
                                }
                                lineLenth = Int32.Parse(szLine.Substring(1, 2), System.Globalization.NumberStyles.HexNumber); // 获取一行的数据个数值
                                startAdr = Int32.Parse(szLine.Substring(3, 4), System.Globalization.NumberStyles.HexNumber); // 获取地址值
                                if (FirstAddrFlag)
                                {
                                    endAdr = startAdr;
                                }
                                else
                                {
                                    FirstAddrFlag = false;
                                }
                                for (i = 0; i < startAdr - endAdr; i++) // 补空位置
                                {
                                    szHex += "FF";
                                }
                                szHex += szLine.Substring(9, lineLenth * 2); //读取有效字符
                                endAdr = startAdr + lineLenth;
                            }
                            else if (szLine.Substring(7, 2) != "01")//不为结束标识
                            {
                                if (SaveMergeHex.Checked == true)
                                {
                                    szTxt += szLine + "\r\n";
                                }
                            }
                        }
                    }
                    BootHexReader.Close(); //关闭目标文件
                }
                pbConvert.Value = 20;
                #endregion

                #region 读取并处理需要转换的hex文件
                pbConvert.Value = 30;
                StreamReader HexReader = new StreamReader(szHexPath);
                FirstLineFlag = true;
                FirstAddrFlag = true;
                while (true)
                {
                    szLine = HexReader.ReadLine(); //读取Hex中一行
                    if (szLine == null) { break; } //读取完毕，退出
                    if (szLine.Substring(0, 1) == ":") //判断首字符是”:”
                    {
                        if (szLine.Substring(7, 2) == "00")//数据记录
                        {
                            if (MergeBoot.Checked == true && SaveMergeHex.Checked == true)
                            {
                                szTxt += szLine + "\r\n";
                            }
                            lineLenth = Int32.Parse(szLine.Substring(1, 2), System.Globalization.NumberStyles.HexNumber); // 获取一行的数据个数值
                            startAdr = Int32.Parse(szLine.Substring(3, 4), System.Globalization.NumberStyles.HexNumber); // 获取地址值
                            if(MergeBoot.Checked == true){//合并文件则不需要初始化结束地址
                                FirstAddrFlag = false;
                            }else{
                                if (FirstAddrFlag)
                                {
                                    endAdr = startAdr;
                                    FirstAddrFlag = false;
                                }
                            }
                            if (startAdr == 0x1A90)
                            {
                            ;
                            }
                            for (i = 0; i < startAdr - endAdr; i++) // 补空位置
                            {
                                szHex += "FF";
                            }
                            szHex += szLine.Substring(9, lineLenth * 2); //读取有效字符
                            endAdr = startAdr + lineLenth;
                        }
                        else if (szLine.Substring(7, 2) == "04")//起始标识
                        {
                            if (FirstLineFlag)
                            {
                                FirstLineFlag = false;
                            }
                            else if (MergeBoot.Checked == true && SaveMergeHex.Checked == true)
                            {
                                szTxt += szLine + "\r\n";
                            }
                        }
                        else
                        {
                            if (MergeBoot.Checked == true && SaveMergeHex.Checked == true)
                            {
                                szTxt += szLine + "\r\n";
                            }
                        }
                    }
                }
                HexReader.Close(); //关闭目标文件
                pbConvert.Value = 50;
                #endregion

                #region 输出合并的Hex文件
                if (MergeBoot.Checked == true && SaveMergeHex.Checked == true)
                {
                    string MergeHexPath = Path.GetDirectoryName(szHexPath) + "\\" + Path.GetFileNameWithoutExtension(szHexPath) + "_Merge.hex";
                    FileStream MergeHex = new FileStream(MergeHexPath, FileMode.OpenOrCreate); //实例化一个文件流，指定文件完整路径，设置模式为打开或在不存在时创建
                    StreamWriter MergeHexStr = new StreamWriter(MergeHex);//实例化文本写入器，指定写入的完全路径，确认写入
                    MergeHexStr.Write(szTxt);
                    MergeHexStr.Close();
                    MergeHexStr.Dispose();
                    MergeHex.Close();//关闭文件流
                    MergeHex.Dispose();//清除文件流
                }
                #endregion

                #region 将hex数据转换为字节数据
                Int32 Length = szHex.Length;
                byte[] szBin = new byte[Length / 2];
                pbConvert.Maximum = Length / 2;

                for (i = 0; i < Length; i += 2) //两字符合并成一个16进制字节
                {
                    szBin[j] = (byte)Int16.Parse(szHex.Substring(i, 2), NumberStyles.HexNumber);
                    j++;
                    pbConvert.Increment(i);
                }
                #endregion

                #region 输出Bin文件
                if (szBinPath == "")//如果没设置输出路径则默认为hex文件路径
                {
                    szBinPath = Path.ChangeExtension(szHexPath, "bin");
                    tbBinPath.Text = szBinPath;
                }
                FileStream fBin = new FileStream(szBinPath, FileMode.OpenOrCreate); //创建文件BIN文件
                BinaryWriter BinWrite = new BinaryWriter(fBin); //二进制方式打开文件
                BinWrite.Write(szBin, 0, szBin.Length);//写入字节
                BinWrite.Flush();//释放缓存
                BinWrite.Close();//关闭文件
                fBin.Close();//关闭文件流
                fBin.Dispose();//清除文件流
                #endregion

                btnOpenHex.Enabled = true;
                btnOut.Enabled = true;
                btnConvert.Enabled = true;
                MessageBox.Show("文件转换完成!        ", "提示");
                pbConvert.Value = 0;//清除进度显示
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


 
    }
}
