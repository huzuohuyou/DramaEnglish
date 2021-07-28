echo %1 %2 %3
D:\Github\DramaEnglish\DramaEnglish.WPF\Words\ffmpeg -i %1 -vf "drawtext=fontcolor=yellow: text='%2':x=100:y=10:fontsize=24:shadowy=2" %3
pause