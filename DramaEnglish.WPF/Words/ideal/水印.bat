echo %1 %2 %3
D:\Github\DramaEnglish\DramaEnglish.WPF\Words\ffmpeg -i D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\ideal\ideal.mp4 -vf "drawtext=fontcolor=yellow: text='Hello World':x=100:y=10:fontsize=24:shadowy=2" ideal_text.mp4 
pause