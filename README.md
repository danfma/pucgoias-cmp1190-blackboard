
# Projeto Quadro-negro compartilhado (Blackboard)

**Intenção do projeto**

> Criar um quadro-negro, superfície para desenhos, o qual compartilha os seus desenhos com os demais
> quadros abertos, na mesma rede, em tempo real.
>
> Toda comunicação entre os quadros deverá ser feita através de troca de mensagens, usando o Middleware
> **Akka** para a transferência das mensagens entre os quadros.
>
> No Akka, um ator é identificado, de forma simplificada, por uma url no formato 
> `akka.tcp://{Ip da máquina}:{Porta}/user/{Nome do ator}`
> será necessário conhecer um determinado endereço para então
> se comunicar com o ator naquele sistema de atores. Logo, será necessário uma forma externa para que os atores
> possam se localizar.
>
> **Para simplificar a implementação**, usaremos um aplicativo singleton, para registro de atores externos.
> Sua função será catalogar os quadros disponíveis na rede e verificar se os quadros estão funcionamento corretamente,
> iniciando a eleição do quadro líder, assim que o líder cair.

**Observação:**

_Quem iniciou o trabalho usando a definição inicial que usava multicast para a descoberta do serviço, poderá
entregá-la sem alteração!_

## Mensagens trocadas entre atores

As mensagens serão objetos simples e serializáveis para transferência de dados. Utilizaremos a seguinte notação, inspirada nas
classes em Scala e Kotlin, para definir as nossas mensagens:

**Mensagem de exemplo `Ping()`**

Representa uma mensagem do tipo `Ping`, sem parâmetros. 

Implementação em Java:

```java

public class Ping implements Serializable {
	
}

```

Implementação em C#:

```csharp

[Serializable]
public class Ping
{
}

```


**Mensagem `Hello(name: string)`**

Representa uma mensagem do tipo `Hello`, com um parâmetro `name`, do tipo `string`. Se houvessem mais parâmetros,
estes podem ser listados dentro dos parênteses, separados por vírgula.

Implementação em Java:

```java

public class Hello implements Serializable {
	public final String name;

	public Hello(String name) {
		this.name = name;
	}
}

```

Implementação em C#:

```csharp

[Serializable]
public class Hello 
{
	public readonly string Name;
	
	public Hello(string name)
	{
		Name = name;
	}
}

```

É importante notar que nesta notação, as implementações dos objetos de transporte não definem métodos para acesso, métodos `get` e `set`.
Todas as classes de objetos de transporte deverão seguir este padrão para garantir a compatibilidade entre os quadros.
As classes em Java deverão estar contidas no pacote `blackboard.messages`, enquanto que, em C#, deverão estar no namespace `Blackboard.Messages`.


# Registro de quadros

Uma aplicação console simples que irá operar sem qualquer interação com o usuário. Sua função é registrar os quadros,
iniciar a eleição e verificar a disponibilidade dos quadros. Esta aplicação deverá ser conhecida de todos os quadros na 
rede (através de um arquivo de configuração ou de passagem de parâmetros).

Este processo, ao iniciar, deverá esperar pelas mensagens externas para então respondê-las adequadamente. 
Salvo o caso este processo ficará "pingando" os quadros já registrados, de tempo em tempo, 
para conferir se o quadro ainda está disponível.

**Funcionalidades:**

* Registrar um quadro-negro;
* Conferir disponibilidade dos quadros já registrados;
* Iniciar uma eleição quando o líder não estiver disponível.


## Registro de novos quadros

Quando um quadro-negro for iniciado, este deverá avisar ao _Registrador de Quadros_ que está disponível, enviando a mensagem
`Available(address: string)`, a qual contém o endereço do ator deste quadro, responsável por receber as mensagens externas. 

O registrador então irá responder com a seguinte mensagem `Registered(id: int)`, e, logo em
seguida, `Leader(address: string)`, contendo o endereço do quadro líder.

Caso este seja o primeiro quadro-negro registrado, também será o líder, recebendo uma mensagem `Leader(address: string)` contendo
o mesmo endereço que enviou na `Available(address: string)`.

## Conferir disponibilidade dos quadros já registrados

A cada 1 segundo, o _Registrador_ irá enviar uma mensagem `Ping()`. Estes deverão responder com uma mensagem `Pong()` em até 5 segundos.


### Mensagens




## Funcionamento

Ao abrir um quadro-negro, este deve iniciar seu sistema de