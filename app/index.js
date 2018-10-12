const Generator = require('yeoman-generator');
const yosay = require('yosay');
const chalk = require('chalk');

module.exports = class extends Generator {
  constructor(args, opts) {
    super(args, opts);

    this.option('service');
    this.option('space');

  
    this.log(chalk.yellow('***********************************************'));
    this.log(yosay('Welcome to the priceless ' + chalk.blue('service template') + ' generator!'));
    this.log(chalk.yellow('***********************************************'));
    this.log(
      chalk.blue(
        '\tService name and Namespace: \n -- can start with letter , _ or $' +
          '\n -- can contain only letters, numbers, _ and $'
      )
    );
    this.log(chalk.yellow('***********************************************'));
    this.log();
  }

  async create() {
    this.serviceName = await this.prompt([
      {
        type: 'input',
        name: 'name',
        message: 'Service name ->  ',
        validate: name => {
          return name.match(/^[a-zA-Z0-9\_\$]+$/) ? true : 'Invalid service name.';
        }
      }
    ]);

    this.nameSpace = await this.prompt([
      {
        type: 'input',
        name: 'name',
        message: 'Namespace  ->  ',
        validate: name => {
          return name.match(/^[a-zA-Z0-9\_\$]+$/) ? true : 'Invalid namespace.';
        }
      }
    ]);

    const openExplorer = () => {
      let execProcess = require('child_process').exec;
      let execPath = 'explorer.exe ^"' + this.config.get('path') + '^"';
      execProcess(execPath);
    };

    this.composeWith(require.resolve('./source-generators/create.js'), { service: this.serviceName.name }).on(
      'end',
      () => {
        this.composeWith(require.resolve('./source-generators/rename.js'), { service: this.serviceName.name });
        this.composeWith(require.resolve('./source-generators/rename-namespace.js'), {
          service: this.serviceName.name,
          space: this.nameSpace.name
        });
        this.composeWith(require.resolve('./source-generators/replace-service.js'), { service: this.serviceName.name });
        this.composeWith(require.resolve('./source-generators/replace-namespace.js'), {
          service: this.serviceName.name,
          space: this.nameSpace.name
        });
        this.composeWith(require.resolve('./source-generators/print.js'));

        openExplorer();
      }
    );
  }
};
