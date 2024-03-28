#!/bin/bash

SHORT_REPO_NAME=`echo $REPO_NAME | sed -e 's/^.*\///'`
URL="https://ggc-itec4650-sp2024.github.io/${SHORT_REPO_NAME}"

html_file='build/WebGL/WebGL/index.html'
if test -f $html_file; then
  echo "File exists. Changin title to ${SHORT_REPO_NAME}"
  sudo chmod 666 $html_file
  cat $html_file | sed -e "s/<title>Unity WebGL Player.*<\/title>/<title>${SHORT_REPO_NAME}<\/title>/" > tmp.html
  cp tmp.html $html_file
fi

readme_file='README.md'
if test -f $readme_file; then
	echo "Readme found"
	if  ! tail -n 2 $readme_file | grep -q "http"; then
		echo "link not found"
		echo $URL >> $readme_file
	fi
fi
