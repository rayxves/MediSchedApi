# :stethoscope: **MediSchedApi**

#### Sistema de Agendamento de Consultas Médicas

---

Este é um **sistema de agendamento de consultas médicas** desenvolvido com o objetivo de **aprender e aplicar conceitos importantes do desenvolvimento de software**. A API permite o gerenciamento de consultas médicas, com diferentes permissões para **pacientes**, **médicos** e **administradores**.

A principal finalidade do projeto é fornecer uma solução simples e eficiente para **agendar** e **gerenciar consultas médicas**, enquanto permite aos administradores gerar relatórios sobre a quantidade de consultas realizadas por médico ou especialidade.

---

## :arrow_right: **Funcionalidades**

- **Agendamento de Consultas**: Pacientes podem agendar novas consultas, especificando seus sintomas e a data/hora.
- **Especialidade**: Médicos possuem uma especialidade associada. Quando pacientes especificam seus sintomas, o agendamento da consulta é feito e o sistema associa a especialidade do médico aos sintomas do paciente, garantindo que o paciente seja direcionado para o profissional mais adequado ao seu caso.
- **Cancelamento de Consultas**: **Médicos**, **pacientes** e **administradores** podem cancelar as consultas agendadas.
- **Gestão de Consultas**: Médicos, pacientes e administradores podem visualizar consultas agendadas ou finalizadas buscando pelo nome do usúario, apenas administradores podem ver todas as consultas.
- **Relatórios**: Administradores podem gerar relatórios sobre o número de consultas realizadas, tanto por médico quanto por especialidade.
- **Gestão de Usuários**: Possibilidade de registrar novos usuários e fazer login. Somente **administradores** podem excluir usuários pelo nome e buscar usuários por **role** (médico ou paciente).
- **Notificação por E-mail**: Envio de notificações automáticas por e-mail para médicos e pacientes quando uma consulta é agendada.
- **Tarefas Agendadas**: O sistema utiliza o **Quartz.NET** para marcar automaticamente as consultas como "finalizadas" no horário determinado.

---

## :bulb: **Aprendizados**

- **Padrão Observer**: Utilizei o padrão **Observer** para enviar notificações por e-mail automaticamente para médicos e pacientes sempre que uma consulta é agendada.
- **Agendamento Automático**: Aprendi a usar o **Quartz.NET** para automatizar tarefas, como a atualização do status das consultas para "finalizadas" no momento determinado.
- **Controle de Roles**: Implementei um controle de **roles** básico (médico, paciente, administrador), garantindo que cada tipo de usuário tenha acesso às funcionalidades específicas.

---

## :computer: **Tecnologias Utilizadas**

- **MailKit**: Para envio de notificações por e-mail.
- **Quartz.NET**: Para agendamento de tarefas, como a atualização automática do status das consultas.
- **Entity Framework Core e PostgreSQL**: Para gerenciamento e persistência de dados no banco de dados.
- **Docker**: Para rodar o banco de dados PostgreSQL em um container, facilitando o setup e a consistência do ambiente de desenvolvimento.
---

## :bookmark_tabs: **Como Rodar o Projeto**

1. Clone o repositório:
   ```bash
   git clone https://github.com/rayxves/MediSchedApi.git
   ```
   
#### :memo: **Preenchendo o `appsettings.json`**

No seu arquivo `appsettings.json`, você precisa preencher as configurações para conectar sua aplicação ao banco de dados, e outras configurações do sistema, como o envio de e-mails e autenticação. Deixei um esqueleto como exemplo.

#### :whale: Inicializando o Container PostgreSQL com Docker

O arquivo docker-compose configura um container para rodar o PostgreSQL com as variáveis de ambiente necessárias
Passos para inicializar o container:

<p>Navegue até o diretório onde o arquivo docker-compose.yml está localizado.</p>

<p>Execute o comando para inicializar o container:</p>

```bash
docker-compose up -d
```
Verifique se o container está em execução:

```bash
docker ps
```

Para parar o container:

```bash
docker-compose down
```
