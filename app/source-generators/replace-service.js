const Generator = require('yeoman-generator');
const path = require('path');
const replace = require('replace');

module.exports = class extends Generator {
  replaceTextPattern() {
    replace({
      paths: [path.join(__dirname, '/..', '/output/', this.options.service)],
      regex: '__Service__',
      replacement: this.options.service,
      recursive: true,
      silent: true
    });
  }
};
