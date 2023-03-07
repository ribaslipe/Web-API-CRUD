-- Table: public.CLIENTE

-- DROP TABLE IF EXISTS public."CLIENTE";

CREATE TABLE IF NOT EXISTS public."CLIENTE"
(
    "COD_CLIENTE" bigint NOT NULL DEFAULT nextval('"CLIENTE_COD_CLIENTE_seq"'::regclass),
    "NOME" text COLLATE pg_catalog."default" NOT NULL,
    "ENDERECO" text COLLATE pg_catalog."default" NOT NULL,
    "CIDADE" text COLLATE pg_catalog."default" NOT NULL,
    "UF" text COLLATE pg_catalog."default" NOT NULL,
    "DATA_INSERCAO" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "CLIENTE_pkey" PRIMARY KEY ("COD_CLIENTE")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."CLIENTE"
    OWNER to postgres;