export interface Processo {
    id: number,
    indice: number
    empresa: string,
    vaga: string,
    aberto: boolean
    valor: number,
    premiado: string,
    indicacoes: Indicacao[]
}

export interface Indicacao {
    aceita: boolean,
    indicante: string,
    linkedin: string
    nomeIndicado: string,
    telefoneIndicado: string,
    sequencial: number
}
  