const Generator = require('yeoman-generator');
const path = require('path');
const replace = require('replace');

module.exports = class extends Generator {
  replaceTextPattern() {
    replace({
      paths: [path.join(__dirname, '/..', '/output/', this.options.service)],
      regex: '__Namespace__',
      replacement: this.options.space,
      recursive: true,
      silent: true
    });
  }
};
