# Programação Orientada a Objetos

Aulas de programação orientada a objetos

## Gerenciador de Bibliotecas

1. Todas as classes possuem atributos que podem ser acessados e editados irrestritamente, fazendo com que firam o Open-Closed Principle do SOLID, sendo abertos para a expansão e alteração de aspectos dentro do programa;
2. O atributo ISBN da classe 'Livro' pode ser considerado Primitive Obsession, sendo mais adequado criar uma classe para esse tipo de dado;
3. Há um excesso de comentários em muitas classes, isso polui o código e faz com que a sua leitura seja prejudicada. Os comentários mais uteis estão presentes dentro dos metodos da classe 'GerenciadorBiblioteca' e do metodo Main;
4. Toda a lógica por trás da adição de um usuário e o envio de um e-mail para ele poderia ser facilitada com a criação de um atributo E-Mail dentro da classe 'Usuário';
5. O fato de enviar SMS ser possível mesmo sem termos informações sobre o número de telefone do usuário não faz sentido;
6. Faria sentido adicionar um atributo de quantidade de livros dentro da Biblioteca, visto que há a possibilidade de existir várias cópias para o mesmo livro;
7. Os metodos que adicionam Livros, Usuários, Enviar E-Mail e SMS estarem dentro da classe 'GerenciadorBiblioteca' vai contra o Single Responsability Principle do SOLID;
8. Não há nenhum fool-proof para casos de adicionarmos um Livro com Autor ou Titulo sendo só um espaço em branco por exemplo.
