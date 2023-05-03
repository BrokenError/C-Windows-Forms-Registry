--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: company; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.company (
    comp_id integer NOT NULL,
    comp_name character varying(100) NOT NULL,
    comp_short_name character varying(50) NOT NULL
);


ALTER TABLE public.company OWNER TO postgres;

--
-- Name: company_comp_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.company_comp_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.company_comp_id_seq OWNER TO postgres;

--
-- Name: company_comp_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.company_comp_id_seq OWNED BY public.company.comp_id;


--
-- Name: document; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.document (
    doc_id integer NOT NULL,
    doc_name character varying(60),
    doc_date date,
    doc_action character varying(50),
    doc_date_action date,
    subd_id1 integer,
    subd_id2 integer
);


ALTER TABLE public.document OWNER TO postgres;

--
-- Name: document_doc_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.document_doc_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.document_doc_id_seq OWNER TO postgres;

--
-- Name: document_doc_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.document_doc_id_seq OWNED BY public.document.doc_id;


--
-- Name: fixed_placement; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.fixed_placement (
    doc_id integer NOT NULL,
    place_id integer NOT NULL
);


ALTER TABLE public.fixed_placement OWNER TO postgres;

--
-- Name: placement; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.placement (
    place_id integer NOT NULL,
    place_type text,
    place_area numeric(7,2)
);


ALTER TABLE public.placement OWNER TO postgres;

--
-- Name: placement_place_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.placement_place_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.placement_place_id_seq OWNER TO postgres;

--
-- Name: placement_place_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.placement_place_id_seq OWNED BY public.placement.place_id;


--
-- Name: subdivision; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.subdivision (
    subd_id integer NOT NULL,
    subd_full_name text NOT NULL,
    subd_short_name character varying(60) NOT NULL,
    genitive text NOT NULL,
    dative text NOT NULL,
    comp_id integer NOT NULL,
    subd_main integer NOT NULL
);


ALTER TABLE public.subdivision OWNER TO postgres;

--
-- Name: subdivision_subd_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.subdivision_subd_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.subdivision_subd_id_seq OWNER TO postgres;

--
-- Name: subdivision_subd_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.subdivision_subd_id_seq OWNED BY public.subdivision.subd_id;


--
-- Name: userr; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.userr (
    userr_id integer NOT NULL,
    userr_name character varying(50) NOT NULL,
    userr_login character varying(100) NOT NULL,
    password character varying(100) NOT NULL,
    is_activate boolean DEFAULT false
);


ALTER TABLE public.userr OWNER TO postgres;

--
-- Name: userr_userr_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.userr_userr_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.userr_userr_id_seq OWNER TO postgres;

--
-- Name: userr_userr_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.userr_userr_id_seq OWNED BY public.userr.userr_id;


--
-- Name: usser; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.usser (
    id integer NOT NULL,
    login character varying(100) NOT NULL,
    password character varying(100) NOT NULL
);


ALTER TABLE public.usser OWNER TO postgres;

--
-- Name: usser_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.usser_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.usser_id_seq OWNER TO postgres;

--
-- Name: usser_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.usser_id_seq OWNED BY public.usser.id;


--
-- Name: company comp_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.company ALTER COLUMN comp_id SET DEFAULT nextval('public.company_comp_id_seq'::regclass);


--
-- Name: document doc_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.document ALTER COLUMN doc_id SET DEFAULT nextval('public.document_doc_id_seq'::regclass);


--
-- Name: placement place_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.placement ALTER COLUMN place_id SET DEFAULT nextval('public.placement_place_id_seq'::regclass);


--
-- Name: subdivision subd_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subdivision ALTER COLUMN subd_id SET DEFAULT nextval('public.subdivision_subd_id_seq'::regclass);


--
-- Name: userr userr_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.userr ALTER COLUMN userr_id SET DEFAULT nextval('public.userr_userr_id_seq'::regclass);


--
-- Name: usser id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usser ALTER COLUMN id SET DEFAULT nextval('public.usser_id_seq'::regclass);


--
-- Data for Name: company; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.company (comp_id, comp_name, comp_short_name) FROM stdin;
2	ООО "Оборонкадастр"	Оборонкадастр
3	ЗАО "Совзонд"	Совзонд
5	ООО "Прайм групп"	Прайм групп
1	ОАО "Роскартография"	Роскартография
4	ОАО "Красная Звезда"	Красная Звезда
\.


--
-- Data for Name: document; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.document (doc_id, doc_name, doc_date, doc_action, doc_date_action, subd_id1, subd_id2) FROM stdin;
1	договор	2023-04-17	закрепить	2023-04-17	1	1
2	приказ	2023-04-17	передать	2023-04-17	2	1
3	приказ	2023-01-22	закрепить	2023-01-23	1	2
4	приказ	2023-01-22	закрепить	2023-01-23	1	3
6	jhj	2023-04-27	hjjjjj	2023-04-27	3	6
7	вввввв	2022-04-26	ввввввввввв	2022-03-04	1	2
\.


--
-- Data for Name: fixed_placement; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.fixed_placement (doc_id, place_id) FROM stdin;
1	2
2	5
3	1
4	2
6	3
6	2
7	2
7	3
\.


--
-- Data for Name: placement; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.placement (place_id, place_type, place_area) FROM stdin;
1	Офис	98.00
2	Офис	60.00
3	Склад	900.00
4	Склад	453.00
5	Отдел	30.00
\.


--
-- Data for Name: subdivision; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.subdivision (subd_id, subd_full_name, subd_short_name, genitive, dative, comp_id, subd_main) FROM stdin;
2	Отдел организации труда и зарплаты	ОТиЗ	Отдела организации труда и зарплаты	Отделу организации труда и зарплаты	1	1
3	Отдел Главного технолога	ОГТ	Отдела Главного технолога	Отделу Главного технолога	1	1
5	Отдел компьютерных технологий	ОКТ	Отдела компьютерных технологий	Отделу компьютерных технологий	2	4
6	Производственное	ПП	Производственному	Производственному	3	6
4	Исследовательско-техническое	ИТ	Исследовательско-технического	Исследовательско-техническому	2	4
1	Финансово-учетное	ФУ	Финансово-учетного	Финансово-учетному	1	1
7	Новый отдел	НО	Нового отдела	Новому отделу	3	6
8	САМ	С	САМА	САМУ	5	8
\.


--
-- Data for Name: userr; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.userr (userr_id, userr_name, userr_login, password, is_activate) FROM stdin;
1	Максим	Maxim01	123	t
2	fgff	fff	1	f
\.


--
-- Data for Name: usser; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.usser (id, login, password) FROM stdin;
1	Менеджер	123
2	Продавец	123456
\.


--
-- Name: company_comp_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.company_comp_id_seq', 1, false);


--
-- Name: document_doc_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.document_doc_id_seq', 1, false);


--
-- Name: placement_place_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.placement_place_id_seq', 1, false);


--
-- Name: subdivision_subd_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.subdivision_subd_id_seq', 1, false);


--
-- Name: userr_userr_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.userr_userr_id_seq', 1, true);


--
-- Name: usser_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.usser_id_seq', 1, false);


--
-- Name: company company_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.company
    ADD CONSTRAINT company_pkey PRIMARY KEY (comp_id);


--
-- Name: document document_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.document
    ADD CONSTRAINT document_pkey PRIMARY KEY (doc_id);


--
-- Name: fixed_placement fixed_placement_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fixed_placement
    ADD CONSTRAINT fixed_placement_pkey PRIMARY KEY (doc_id, place_id);


--
-- Name: placement placement_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.placement
    ADD CONSTRAINT placement_pkey PRIMARY KEY (place_id);


--
-- Name: subdivision subdivision_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subdivision
    ADD CONSTRAINT subdivision_pkey PRIMARY KEY (subd_id);


--
-- Name: userr userr_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.userr
    ADD CONSTRAINT userr_pkey PRIMARY KEY (userr_id);


--
-- Name: usser usser_login_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usser
    ADD CONSTRAINT usser_login_key UNIQUE (login);


--
-- Name: usser usser_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usser
    ADD CONSTRAINT usser_pkey PRIMARY KEY (id);


--
-- Name: document document_subd_id1_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.document
    ADD CONSTRAINT document_subd_id1_fkey FOREIGN KEY (subd_id1) REFERENCES public.subdivision(subd_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: document document_subd_id2_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.document
    ADD CONSTRAINT document_subd_id2_fkey FOREIGN KEY (subd_id2) REFERENCES public.subdivision(subd_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: fixed_placement fixed_placement_doc_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fixed_placement
    ADD CONSTRAINT fixed_placement_doc_id_fkey FOREIGN KEY (doc_id) REFERENCES public.document(doc_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: fixed_placement fixed_placement_place_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fixed_placement
    ADD CONSTRAINT fixed_placement_place_id_fkey FOREIGN KEY (place_id) REFERENCES public.placement(place_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: subdivision subdivision_comp_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subdivision
    ADD CONSTRAINT subdivision_comp_id_fkey FOREIGN KEY (comp_id) REFERENCES public.company(comp_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: subdivision subdivision_subd_main_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subdivision
    ADD CONSTRAINT subdivision_subd_main_fkey FOREIGN KEY (subd_main) REFERENCES public.subdivision(subd_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

