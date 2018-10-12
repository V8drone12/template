const Generator = require('yeoman-generator');
const yosay = require('yosay');
const chalk = require('chalk');

module.exports = class extends Generator {
  printInfo() {
    this.log();
    this.log();
    this.log(chalk.yellow('*******************************************'));
    this.log(chalk.yellow('*                 DATA INFO               *'));
    this.log(chalk.yellow('*******************************************'));
    this.log(
      chalk.blue('Files') + ' and ' + chalk.blue('Directories') + ' renamed ' + chalk.green(this.config.get('renamed'))
    );
    this.log(chalk.blue('Directories') + ' created ' + chalk.green(this.config.get('dir')));
    this.log(chalk.blue('Files') + ' created ' + chalk.green(this.config.get('files')));
    this.log(
      chalk.blue('Total files') +
        ' and ' +
        chalk.blue('directories ') +
        chalk.green(this.config.get('dir') + this.config.get('files'))
    );
    this.log(chalk.yellow('*******************************************'));
    this.log(chalk.yellow('*******************************************'));
  }
};
