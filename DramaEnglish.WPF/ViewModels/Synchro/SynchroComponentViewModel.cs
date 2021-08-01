using CommonService.Lines;
using DramaEnglish.WPF.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.IO;
using System.Threading.Tasks;

namespace DramaEnglish.UserInterface.ViewModels.Synchro
{
    public class SynchroComponentViewModel : ViewModelBase
    {

        #region 字段属性

        private string scanedWords;
        public string ScanedWords { get { return scanedWords; } set { SetProperty(ref scanedWords, value); } }

        private int minimum = 0;
        public int Minimum { get { return minimum; } set { SetProperty(ref minimum, value); } }

        private int maximum;
        public int Maximum { get { return maximum; } set { SetProperty(ref maximum, value); } }

        private int currentIndex = 0;
        public int CurrentIndex { get { return currentIndex; } set { SetProperty(ref currentIndex, value); } }

        private string currentIndexStr = "点我扫描=>";
        public string CurrentIndexStr { get { return currentIndexStr; } set { SetProperty(ref currentIndexStr, value); } }

        #endregion

        #region 构造函数
        public SynchroComponentViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator ea)
         : base(regionManager, dialogService, ea)
        {
        }
        #endregion

        #region 命令
        public DelegateCommand SyncWordInfoCommand => new(() =>
        {
            Task.Run(() =>
            {
                var path = $@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words";
                DirectoryInfo theFolder = new DirectoryInfo(path);
                var dirs = theFolder.GetDirectories();

                Maximum = dirs.Length - 1;

                foreach (var item in dirs)
                {
                    var HAVEMP4 = 0;
                    CurrentIndexStr = $@"{CurrentIndex}/{Maximum}";
                    CurrentIndex++;
                    var detail = string.Empty;
                    try
                    {
                        var detailpath = $@"{path}\{item.Name}\{item.Name}.txt";
                        if (File.Exists(detailpath))
                            using (StreamReader sr = new StreamReader(detailpath))
                            {
                                detail = sr.ReadToEnd();
                            }
                        if (File.Exists($@"{path}\{item.Name}\{item.Name}.mp4"))
                        {
                            HAVEMP4 = 1;
                        }

                    }
                    catch (System.Exception ex)
                    {
                        ScanedWords += $"\n\r**************************{ ex.Message} **************************";
                    }
                    var currentWord = CommonService.DB.WordDBService.GetWORD(item.Name);
                    if (currentWord == null)
                        currentWord = new CommonService.DB.WORD
                        {
                            EN = item.Name,
                            DETAIL = detail.Split("    ").Length >= 2 ? detail.Split("    ")[1] : "",
                            LINES = new GetCeanLinesService().GetCleanLins(item.Name),
                            WORDGROUP = "英语二",
                            HAVEMP4 = HAVEMP4
                        };
                    else
                    {
                        currentWord.HAVEMP4 = HAVEMP4;
                        currentWord.DETAIL = detail.Split("    ").Length >= 2 ? detail.Split("    ")[1] : "";
                        currentWord.LINES = new GetCeanLinesService().GetCleanLins(item.Name);
                    }
                    var ok = CommonService.DB.WordDBService.AddorUpdateWord(currentWord);
                    ScanedWords = $"\n\r OK：{ok}    {CurrentIndexStr}    单词：{item.Name}    媒体文件：{HAVEMP4}    翻译：{currentWord.DETAIL}" + ScanedWords;
                }
                //DialogService.Show("SuccessDialog", new DialogParameters($"message={"单词同步成功!"}"), null);
            });


        });


        #endregion

        #region 方法函数

        #endregion

    }
}
