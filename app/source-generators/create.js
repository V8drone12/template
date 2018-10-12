'use strict';
const Generator = require('yeoman-generator');
const path = require('path');

module.exports = class extends Generator {
  copyStructure() {
    this.config.set('path', path.join(__dirname, '/..', '/output/'));

    this.destinationRoot(path.join(__dirname, '/..', '/output/', this.options.service));
    this.fs.copyTpl(this.templatePath(path.join(__dirname, '/..', '/templates')), this.destinationPath('./'));
  }
};
