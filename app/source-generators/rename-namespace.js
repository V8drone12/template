const Generator = require('yeoman-generator');
const path = require('path');
const fs = require('fs');

module.exports = class extends Generator {
  constructor(args, opts) {
    super(args, opts);
  }

  renameFileStructure() {
    let filesChanged = 0;
    let nrFiles = 0;
    let nrDir = 0;

    const renameServiceOccurrence = text => {
      text.includes('__Namespace__') ? filesChanged++ : null;
      return text.replace(/__Namespace__/g, this.options.space);
    };

    const countFilesAndDirs = file => {
      file.isDirectory() ? nrDir++ : nrFiles++;
    };

    const renameDir = dir => {
      let path;
      let newPath;
      let file;

      const files = fs.readdirSync(dir);

      files.forEach(fileSys => {
        path = dir + '/' + fileSys;
        newPath = dir + '/' + renameServiceOccurrence(fileSys);

        file = fs.statSync(path);
        fs.renameSync(path, newPath);

        if (file.isDirectory()) {
          renameDir(newPath);
        }

        countFilesAndDirs(file);
      });
    };

    renameDir(path.join(__dirname, '/..', '/output/', this.options.service));

    this.config.set('renamed', filesChanged);
    this.config.set('dir', nrDir);
    this.config.set('files', nrFiles);
  }
};
